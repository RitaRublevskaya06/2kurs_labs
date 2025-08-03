import { useState } from 'react';
import type { Post, NewPost } from '../features/posts/postsAPI';
import '../styles.css';

interface PostFormProps {
  initialPost?: Post;
  onSubmit: (post: Post | NewPost) => void;
}

export const PostForm = ({ initialPost, onSubmit }: PostFormProps) => {
  const [post, setPost] = useState(initialPost || { title: '', body: '' });

const handleSubmit = (e: React.FormEvent) => {
  e.preventDefault();
  if (!post.title || !post.body) return;
  
  const tempId = Date.now();
  onSubmit({ ...post, tempId });
  
  if (!initialPost) setPost({ title: '', body: '' });
};

  return (
    <form className="post-form" onSubmit={handleSubmit}>
      <input
        className="form-input"
        placeholder="Заголовок"
        value={post.title}
        onChange={(e) => setPost({ ...post, title: e.target.value })}
      />
      <textarea
        className="form-input form-textarea"
        placeholder="Текст поста"
        value={post.body}
        onChange={(e) => setPost({ ...post, body: e.target.value })}
      />
      <div className="button-group">
        <button className="btn btn-primary" type="submit">
          {initialPost ? 'Обновить' : 'Создать'}
        </button>
      </div>
    </form>
  );
};