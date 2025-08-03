export interface Todo {
    id: number;
    text: string;
    completed: boolean;
  }
  
  export type TodoState = Todo[];
  
  export enum ActionTypes {
    ADD_TODO = "ADD_TODO",
    TOGGLE_TODO = "TOGGLE_TODO",
    EDIT_TODO = "EDIT_TODO",
    DELETE_TODO = "DELETE_TODO",
  }
  
  export type TodoAction =
    | { type: ActionTypes.ADD_TODO; payload: string }
    | { type: ActionTypes.TOGGLE_TODO; payload: number }
    | { type: ActionTypes.EDIT_TODO; payload: { id: number; text: string } }
    | { type: ActionTypes.DELETE_TODO; payload: number };