import React, { useState} from "react";
import { NavLink, useNavigate, useLocation } from 'react-router-dom';

export default function CreateItinerary() {
    const navigate = useNavigate();
    const location = useLocation();
    

    const [formData, setFormData] = useState({
        name: "",
        start: "",
        end: "",
        transportation: "",
        location: "",
        userId: location.state.id,
        img: "icon.png"
    })
    

    function handleChange(event){
        const {name, value,} = event.target
        setFormData(prevFormData => ({
            ...prevFormData,
            [name]: value
        }))
    }

    console.log(formData.img)
    async function handleSubmit(event) {
        event.preventDefault()
            try {
                const response = await fetch(`https://localhost:7046/api/Itinerary`, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(formData),
                });
        
                if (response.ok) {
                console.log('Form data submitted successfully');
                // You might want to handle success here, like showing a success message
                } else {
                console.error('Error submitting form data');
                // Handle the error scenario here, like showing an error message
                }
            } catch (error) {
                console.error('An error occurred', error);
        }
        navigate('/')
        
    }
    return (
    <div className="form-outer">
    <div className="form-container">
    <form className="form" onSubmit={handleSubmit}>
        <img src="../../images/icon-removebg-preview.png" alt="company logo" className='header--logo'/>
        <input 
            type="text" 
            placeholder="Name"
            className="form--input"
            name="name"
            onChange={handleChange}
            value={formData.name}
        />
        <input 
            type="date" 
            className="form--input"
            name="start"
            onChange={handleChange}
            value={formData.start}
        />
        <input 
            type="date" 
            className="form--input"
            name="end"
            onChange={handleChange}
            value={formData.end}
        />
        <select
            name="transportation"
            className="form--input"
            onChange={handleChange}
            value={formData.transportation}
        >
            <option value="airplane">Airplane</option>
            <option value="bus">Bus</option>
            <option value="car">Car</option>
            <option value="train">Train</option>
        </select>
        <input 
            type="text" 
            placeholder="Eg. Addis Ababa, Ethiopia"
            className="form--input"
            name="location"
            onChange={handleChange}
            value={formData.location}
        />
        <button>
            Done
        </button>
        <div className="form--links">
            <span className="form-link" onClick={()=> navigate(-1)}>Back</span>
            <NavLink to="/">Home</NavLink>
        </div>
    </form>
    </div>
    </div>
)


}