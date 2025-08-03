import React from 'react';
import { useSelector } from 'react-redux';
import { RootState } from '../../redux/store';
import TodoItem from '../TodoItem/TodoItem';
import styles from './TodoList.module.css';

export const TodoList: React.FC = () => {
  const todos = useSelector((state: RootState) => state.todos);

  return (
    <div className={styles.container}>
      {todos.length === 0 ? (
        <p className={styles.emptyMessage}>Нет задач. Добавьте первую!</p>
      ) : (
        <ul className={styles.todoList}>
          {todos.map((todo) => (
            <TodoItem key={todo.id} todo={todo} />
          ))}
        </ul>
      )}
    </div>
  );
};

export default TodoList;
