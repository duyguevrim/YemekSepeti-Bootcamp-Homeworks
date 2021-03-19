import {FaPlus} from "react-icons/fa";
import {Component} from "react";

class PrimaryButton extends Component {
    render() {
        return (
            <>
                <div className="pt-3">
                    <button onClick={this.props.myClick} type="button">
                        {this.props.isIncludeIcon ? <FaPlus/> : null}
                        <span>{this.props.title}</span>
                    </button>
                </div>
                <style jsx>{`
                  button {
                    display: flex;
                    align-items: center;
                    text-align: center;
                    text-decoration: none;
                    margin: 2px 0;
                    border: transparent;
                    border-radius: 6px;
                    color: ${this.props.color};
                    font-size: 1rem;
                    padding: .8rem 1.5rem;
                    font-weight: 600;
                    background: ${this.props.bgColor};
                    cursor: pointer;
                  }

                  button:hover {
                    color: ${this.props.bgColor};
                    background-color: ${this.props.color};
                  }
                `}</style>
            </>
        );
    }

}

export default PrimaryButton;
