import {useDispatch} from "react-redux";
import moment from "moment";
import {deleteTodo, updateTodo} from "../redux/actions";
import {FaEdit, FaTrashAlt} from "react-icons/all";
import React, {useState} from "react";
import {Modal} from "react-bootstrap";
import DatePicker from "react-datepicker";
import PrimaryButton from "./PrimaryButton";
import {toast} from "react-toastify";


function notify(isSuccess, message) {
    if (isSuccess)
        toast.success(message);
    else
        toast.error(message);
}

const TodoItem = ({todo}) => {
    const [show, setShow] = useState(false);
    let [name, setName] = useState(todo.name);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const [startDate, setStartDate] = useState(new Date(todo.date));
    let dispatch = useDispatch();
    return (
        <>
            <li
                className="todo d-flex align-items-center justify-content-between pt-4">
                <div className="d-flex pl-1">
                    <span className="bullet bullet-bar bg-success align-self-stretch"></span>
                    <div>
                        <p className="todo-text m-0 pl-2">{todo.name}</p>
                        <span className="text-muted font-weight-bold pl-2">
                                                    {moment(todo.date).format("Do MMM YY") + " (" + moment(todo.date, "YYYYMMDD").fromNow() + ")"}
                                                </span>

                    </div>
                </div>
                <div>
                    <a onClick={handleShow} className="edit-icon pr-4">
                        <FaEdit/>
                    </a>
                    <a onClick={() => dispatch(deleteTodo(todo.id))} className="delete-icon pr-4">
                        <FaTrashAlt/>
                    </a>
                </div>
                <Modal centered dialogClassName="modal-90w" aria-labelledby="example-custom-modal-styling-title"
                       show={show} onHide={handleClose}>
                    <Modal.Header closeButton>
                        <Modal.Title>Update Todo Modal</Modal.Title>
                    </Modal.Header>
                    <Modal.Body className="p-4">
                        <div className="form-group">
                            <label className="form-title">Todo Content</label>
                            <input className="form-control modal-input" type="text"
                                   onChange={(e) => setName(e.target.value)}
                                   value={name}/>

                        </div>
                        <div className="form-group">
                            <label className="form-title">Todo Date</label>
                            <DatePicker className="form-control modal-input" selected={startDate}
                                        onChange={date => setStartDate(date)}/>
                        </div>
                    </Modal.Body>
                    <Modal.Footer>
                        <PrimaryButton
                            title="Close"
                            myClick={handleClose}
                            isIncludeIcon={false}
                            bgColor="#E1F0FF"
                            color="#3699FF"
                        />
                        <PrimaryButton
                            title="Save Changes"
                            myClick={() => {
                                if (name === "") {
                                    notify(false, "You cannot enter empty todo! Please enter a valid todo.");
                                } else {
                                    dispatch(updateTodo({
                                        ...todo,
                                        name: name,
                                        date: startDate
                                    }))
                                    notify(true, "Todo updated successfully..");
                                    handleClose();
                                }
                            }}
                            isIncludeIcon={false}
                            bgColor="#E1F0FF"
                            color="#3699FF"
                        />


                    </Modal.Footer>
                </Modal>
            </li>
            <style jsx>{
                `
                  .modal-90w {
                    width: 1000px !important;

                  }

                  .text-muted {
                    color: #B5B5C3 !important;
                  }

                  .bullet.bullet-bar {
                    width: 4px;
                    height: auto;
                  }

                  .bullet {
                    display: inline-block;
                    background-color: #E4E6EF;
                    width: 10px;
                    height: 2px;
                    border-radius: 2rem;
                    margin-left: 1rem;
                  }

                  .bg-success {
                    background-color: #3699FF !important;
                  }

                  .form-title {
                    font-size: 1.2rem;
                    font-weight: bold;
                  }

                  .modal-input {
                    padding: 1rem !important;
                    background: #F3F6F9;
                    border-color: white;
                    color: #3F4254;
                    height: 55px;
                    border-radius: 0.85rem !important;
                  }

                  .delete-icon {
                    color: #F64E60 !important;
                    cursor: pointer;
                    padding-right: 2rem;
                    font-size: 2em;
                  }

                  .edit-icon {
                    color: #FFA800 !important;
                    cursor: pointer;
                    padding-right: 2rem;
                    font-size: 2em;
                  }
                `
            }</style>
        </>
    );
}

export default TodoItem;
