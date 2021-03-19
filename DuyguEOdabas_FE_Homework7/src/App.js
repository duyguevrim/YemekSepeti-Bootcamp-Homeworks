import './App.css';
import TodoList from "./components/TodoList";
import AddTodo from "./components/AddTodo";
import Navbar from "./components/Navbar";
import 'react-toastify/dist/ReactToastify.css';

function App() {
    return (
            <div className="container w-30">
                <Navbar />
                <AddTodo/>
                <TodoList/>
            </div>
    );
}

export default App;
