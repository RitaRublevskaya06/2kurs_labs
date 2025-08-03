import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';
import type { Post, NewPost } from './postsAPI';
import { fetchPosts, createPost, updatePost, deletePost } from './postsAPI';

interface PostsState {
  posts: Post[];
  status: 'idle' | 'loading' | 'failed';
}

const initialState: PostsState = {
  posts: [],
  status: 'idle',
};

export const getPosts = createAsyncThunk('posts/fetchPosts', async () => {
  return await fetchPosts();
});

export const addPost = createAsyncThunk('posts/createPost', async (post: NewPost) => {
  return await createPost(post);
});

export const editPost = createAsyncThunk('posts/updatePost', async (post: Post) => {
  return await updatePost(post);
});

export const removePost = createAsyncThunk('posts/deletePost', async (id: number) => {
  await deletePost(id);
  return id;
});

const postsSlice = createSlice({
  name: 'posts',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(getPosts.pending, (state) => {
        state.status = 'loading';
      })
      .addCase(getPosts.fulfilled, (state, action) => {
        state.status = 'idle';
        state.posts = action.payload;
      })
      .addCase(addPost.pending, (state, action) => {
      const newPost = {
        ...action.meta.arg,
        id: action.meta.arg.tempId || Date.now(),
      };
      state.posts.unshift(newPost as Post);
    })
    .addCase(addPost.fulfilled, (state, action) => {
      const index = state.posts.findIndex(post => post.id === action.payload.id);
      if (index !== -1) {
        state.posts[index] = action.payload;
      }
    })
    .addCase(addPost.rejected, (state, action) => {
      state.posts = state.posts.filter(
        post => post.id !== action.meta.arg.tempId
      );
    })
    .addCase(editPost.pending, (state, action) => {
      const { id } = action.meta.arg;
      const index = state.posts.findIndex(post => post.id === id);
      if (index !== -1) {
        state.posts[index] = { ...state.posts[index], ...action.meta.arg };
      }
    })
    .addCase(removePost.pending, (state, action) => {
      state.posts = state.posts.filter(post => post.id !== action.meta.arg);
    });
  },
});

export default postsSlice.reducer;