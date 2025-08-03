import AddTodo from './components/AddTodo/AddTodo';
import TodoList from './components/TodoList/TodoList';

function App() {
  return (
    <div>
      <h1>Список дел с использованием RTK</h1>
      <AddTodo />
      <TodoList />
    </div>
  );
}

export default App;