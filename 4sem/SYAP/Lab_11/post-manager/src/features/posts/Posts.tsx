import { useEffect, useState } from 'react';
import { useAppDispatch, useAppSelector } from '../../app/store';
import { getPosts, removePost, addPost, editPost } from './postsSlice';
import { PostForm } from '../../components/PostForm';
import { PostItem } from '../../components/PostItem';
import type { Post, NewPost } from './postsAPI';
import type { RootState } from '../../app/store';
import '../../styles.css';

export const Posts = () => {
  const dispatch = useAppDispatch();
  const { posts, status } = useAppSelector((state: RootState) => state.posts);
  const [editingPost, setEditingPost] = useState<Post | null>(null);

  useEffect(() => {
    dispatch(getPosts());
  }, [dispatch]);

const handleSubmit = (postData: Post | NewPost) => {
  if (editingPost) {
    dispatch(editPost({ ...editingPost, ...postData }));
    setEditingPost(null);
  } else {
    dispatch(addPost(postData));
  }
};
  return (
    <div className="container">
      <h1>Post Manager</h1>
      
      <PostForm 
        onSubmit={handleSubmit} 
        initialPost={editingPost || undefined} 
      />

      <div className="post-list">
        {status === 'loading' ? (
          <div className="loading">Загрузка...</div>
        ) : (
          posts.map((post) => (
            <PostItem
              key={post.id}
              post={post}
              onEdit={setEditingPost}
              onDelete={(id: number) => dispatch(removePost(id))}
            />
          ))
        )}
      </div>
    </div>
  );
};

export default Posts;