import React, { useState } from "react";
import { useAppDispatch } from "../../redux/hooks";
import { added } from "../../redux/features/todos/todosSlice";
import styles from "./AddTodo.module.css";

const AddTodo: React.FC = () => {
  const [text, setText] = useState("");
  const dispatch = useAppDispatch();

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (text.trim()) {
      dispatch(added(text));
      setText("");
    }
  };

  return (
    <form onSubmit={handleSubmit} className={styles.addTodoForm}>
      <input
        type="text"
        value={text}
        onChange={(e) => setText(e.target.value)}
        placeholder="Добавить новую задачу..."
        className={styles.addTodoInput}
      />
      <button type="submit" className={styles.addTodoButton}>
        Добавить
      </button>
    </form>
  );
};

export default AddTodo;