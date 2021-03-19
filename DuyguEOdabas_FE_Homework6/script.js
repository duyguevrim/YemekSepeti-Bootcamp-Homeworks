var taskList = [];

document.addEventListener("DOMContentLoaded", () => {
    if (JSON.parse(localStorage.getItem('taskList'))) {
        taskList = JSON.parse(localStorage.getItem('taskList'));
        console.log(taskList);
        taskList.map(todo => {
            console.log(todo);
            getToDoElements(todo);
        });
    } else
        localStorage.setItem("taskList", JSON.stringify(taskList));

});

function getToDoElements(todoContent) {
    const todoList = document.querySelector("#todo-list");
    var mainDiv = document.createElement("li");
    mainDiv.className = 'todo d-flex align-items-center justify-content-between pt-4';
    var todoInfoDiv = document.createElement("div");
    todoInfoDiv.className = 'd-flex pl-1';
    var span = document.createElement("span");
    span.className = 'bullet bullet-bar bg-success align-self-stretch';
    var p = document.createElement("p");
    p.className = 'todo-text m-0';
    p.innerText = todoContent;
    var i = document.createElement("i");
    i.className = 'fa fa-trash delete-icon';
    i.addEventListener(('click'), (e) => {
        todoList.removeChild(mainDiv);
        taskList = taskList.filter(todo => todo !== p.innerText);
        localStorage.setItem("taskList", JSON.stringify(taskList));
    });
    todoInfoDiv.appendChild(span);
    todoInfoDiv.appendChild(p);
    mainDiv.appendChild(todoInfoDiv);
    mainDiv.appendChild(i);
    todoList.appendChild(mainDiv);
}

function createNewToDo() {
    const todoText = document.querySelector("#text-input");
    getToDoElements(todoText.value)
    console.log(todoText);
    taskList.push(todoText.value);
    todoText.value = "";
    localStorage.setItem("taskList", JSON.stringify(taskList));

}








