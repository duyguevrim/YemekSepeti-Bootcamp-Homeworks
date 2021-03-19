import React from "react";
import {useSelector} from "react-redux";
import TodoItem from "./TodoItem";

const TodoList = () => {

    let todos = useSelector(state => state)
    return (
        <>
            <div className="pt-5">
                <div className="card-custom py-4">
                    <div className="d-flex justify-content-between">
                        <h3 className="text-dark card-title pl-4">Todo List</h3>
                    </div>
                    <ul>
                        {todos.map((todo) => {
                            return <TodoItem key={todo.id} todo={todo}/>
                        })}
                    </ul>
                </div>
                <style jsx>{`
                  .text-dark {
                    color: #181C32 !important;
                  }
           
                  .card-custom {
                    -webkit-box-shadow: 0px 0px 30px 0px rgb(82 63 105 / 5%);
                    box-shadow: 0px 0px 30px 0px rgb(82 63 105 / 5%);
                    border: 0;
                    background: white;
                    border-radius: 0.42rem;
                  }
                `}</style>
            </div>


        </>
    )
}

export default TodoList;
