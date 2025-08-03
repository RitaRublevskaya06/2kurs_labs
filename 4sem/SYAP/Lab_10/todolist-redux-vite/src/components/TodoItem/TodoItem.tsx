import { useState } from "react";
import { useAppDispatch } from "../../redux/hooks";
import { toggled, edited, deleted } from "../../redux/features/todos/todosSlice";
import styles from "./TodoItem.module.css";

interface TodoItemProps {
  todo: {
    id: number;
    text: string;
    completed: boolean;
  };
}

const TodoItem = ({ todo }: TodoItemProps) => {
  const dispatch = useAppDispatch();
  const [isEditing, setIsEditing] = useState(false);
  const [editText, setEditText] = useState(todo.text);

  const handleEdit = () => {
    if (editText.trim()) {
      dispatch(edited({ id: todo.id, text: editText }));
      setIsEditing(false);
    }
  };

  return (
    <li className={styles.todoItem}>
      <div className={styles.taskContainer}>
        <label className={styles.checkboxLabel}>
          <input
            type="checkbox"
            checked={todo.completed}
            onChange={() => dispatch(toggled(todo.id))}
            className={styles.checkbox}
            aria-label={todo.completed ? `Отметить "${todo.text}" невыполненной` : `Отметить "${todo.text}" выполненной`}
          />
          {!isEditing && (
              <span 
                  className={`${styles.todoText} ${todo.completed ? styles.completed : ''}`}
                  onClick={() => setIsEditing(true)}
                    >
                  {todo.text}
              </span>
          )}
        </label>
       
        {isEditing && (
          <input
            type="text"
            value={editText}
            onChange={(e) => setEditText(e.target.value)}
            onBlur={handleEdit}
            onKeyPress={(e) => e.key === "Enter" && handleEdit()}
            autoFocus
            className={styles.editInput}
            aria-label="Редактировать текст задачи"
            placeholder="Редактировать задачу"
          />
        )}
      </div>
      
      <div className={styles.buttons}>
        <button
          onClick={() => setIsEditing(!isEditing)}
          className={styles.editButton}
          aria-label={isEditing ? "Отменить редактирование" : `Редактировать "${todo.text}"`}
        >
          {isEditing ? "Отмена" : "Редактировать"}
        </button>
        <button
          onClick={() => dispatch(deleted(todo.id))}
          className={styles.deleteButton}
          aria-label={`Удалить "${todo.text}"`}
        >
          Удалить
        </button>
      </div>
    </li>
  );
};

export default TodoItem;