import { useAppSelector } from '../../redux/hooks';
import TodoItem from '../TodoItem/TodoItem';

const TodoList = () => {
  const todos = useAppSelector((state) => state.todos.items);

  return (
    <ul>
      {todos.map((todo) => (
        <TodoItem key={todo.id} todo={todo} />
      ))}
    </ul>
  );
};

export default TodoList;