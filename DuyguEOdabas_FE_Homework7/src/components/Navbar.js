import logo from '../assets/logo.png'

const Navbar = () => {
    return (
        <>
            <div className="mt-5">
                <div className="d-flex justify-content-center align-items-center pt-4">
                    <img alt="Todo List Icon" src={logo}
                         width="100" height="100" /></div>
                <h2 className="text-center pt-2 font-weight-bold">Todo List</h2>
                <hr />
            </div>
        </>
    )
}
export default Navbar;
