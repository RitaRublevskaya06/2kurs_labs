import { ActionTypes } from "../types";

export const addTodo = (text: string) => ({
  type: ActionTypes.ADD_TODO,
  payload: text,
});

export const toggleTodo = (id: number) => ({
  type: ActionTypes.TOGGLE_TODO,
  payload: id,
});

export const editTodo = (id: number, text: string) => ({
  type: ActionTypes.EDIT_TODO,
  payload: { id, text },
});

export const deleteTodo = (id: number) => ({
  type: ActionTypes.DELETE_TODO,
  payload: id,
});