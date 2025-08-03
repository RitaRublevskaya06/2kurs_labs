import AddTodo from './components/AddTodo/AddTodo';
import TodoList from './components/TodoList/TodoList';
import './App.css';

function App() {
  return (
    <div className="app">
      <h1>Список дел с использованием Redux</h1>
      <AddTodo />
      <TodoList />
    </div>
  );
}

export default App;