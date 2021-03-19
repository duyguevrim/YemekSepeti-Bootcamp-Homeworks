import React, {useState} from "react";
import PrimaryButton from "./PrimaryButton";
import DatePicker from "react-datepicker";
import {toast, ToastContainer} from "react-toastify";
import {v1 as uuid} from 'uuid';
import {addTodo} from "../redux/actions";
import {useDispatch} from "react-redux";

function notify(isSuccess, message) {
    if (isSuccess)
        toast.success(message);
    else
        toast.error(message);
}

const AddTodo = () => {
    let [name, setName] = useState();
    let dispatch = useDispatch();
    const [startDate, setStartDate] = useState(new Date());

    return (
        <>
            <div className="d-flex flex-column">
                <div className="form-group">
                    <label className="font-size-h6">Add Todo</label>
                    <input placeholder="Write your todo..."  className="form-control mt-2" type="text"
                           onChange={(e) => setName(e.target.value)}
                           value={name}/>

                </div>
                <div className="form-group">
                    <DatePicker className="form-control mt-2" selected={startDate} onChange={date => setStartDate(date)} />
                </div>
                <PrimaryButton
                    title="Add New Todo"
                    myClick={() => {
                        console.log(name);
                        if(name === "" || name === undefined){
                            notify(false, "You cannot enter empty todo!. Please enter a valid todo.");
                        }
                        else{
                            dispatch(addTodo({
                                id: uuid(),
                                name: name,
                                date: startDate
                            }))
                            notify(true, 'Todo successfully added..');
                            setName('');
                        }
                    }}
                    isIncludeIcon={true}
                    bgColor="#E1F0FF"
                    color="#3699FF"
                />
                <ToastContainer/>
            </div>
            <style jsx>{
                `
                  .form-control:focus {
                    border: red !important;
                  }

                  .font-size-h6 {
                    font-size: 1.75rem !important;
                  }

                  .form-control {
                    padding: 1rem !important;
                    background: white;
                    border-color: white;
                    color: #3F4254;
                    height: 55px;
                    border-radius: 0.85rem !important;
                  }
                `
            }</style>
        </>
    )
}

export default AddTodo;
