import type { Post } from '../features/posts/postsAPI';
import '../styles.css';

interface PostItemProps {
  post: Post;
  onEdit: (post: Post) => void;
  onDelete: (id: number) => void;
}

export const PostItem = ({ post, onEdit, onDelete }: PostItemProps) => (
  <div className="post-card">
    <h3>{post.title}</h3>
    <p>{post.body}</p>
    <div className="button-group">
      <button className="btn btn-edit" onClick={() => onEdit(post)}>
        Редактировать
      </button>
      <button className="btn btn-danger" onClick={() => onDelete(post.id)}>
        Удалить
      </button>
    </div>
  </div>
);