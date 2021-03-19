import {ADD_TODO, UPDATE_TODO, DELETE_TODO} from './actions';
import {todos} from "./states";

export let reducer = (state = todos, action) => {
    let newTodos = [...state];
    switch (action.type) {
        case ADD_TODO:
            newTodos.push(action.payload);
            localStorage.setItem("todos", JSON.stringify(newTodos));
            return newTodos;
        case UPDATE_TODO:
            let index = -1;
            for (let i = 0; i < newTodos.length; i++) {
                index++;
                if (newTodos[i].id == action.payload.id) {
                    break;
                }
            }
            if (index != -1) {
                newTodos[index] = action.payload;
                localStorage.setItem("todos", JSON.stringify(newTodos));
                return newTodos;
            }
        case DELETE_TODO:
            newTodos = newTodos.filter(todo => todo.id != action.payload);
            localStorage.setItem("todos", JSON.stringify(newTodos));
            return newTodos;
        default:

            return state;
    }
}
