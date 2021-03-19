export let todos;

if (JSON.parse(localStorage.getItem("todos"))) {
    todos = JSON.parse(localStorage.getItem("todos"));
} else {
    todos = [];
    localStorage.setItem("todos", JSON.stringify(todos));
}
