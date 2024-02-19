import React, { useState, useEffect } from "react";
import { NavLink, useNavigate } from 'react-router-dom';


export default function LogIn() {
    const navigate = useNavigate();
    var img = "";
    var flag = false;

    const [formData, setFormData] = useState({
        email: "",
        password: ""
    })

    const [profileData, setProfileData] = useState([])

    useEffect(() => {
        const fetchCard = async () => {
        const res = await fetch(`https://localhost:7046/api/User`)
        const data = await res.json()
          setProfileData(data)
        }
        fetchCard().catch((error) => console.error(error));
      }, []);

    function handleSubmit(event) {
        event.preventDefault()
    }

    function handleClick(){

        for(var user of profileData){
            if(formData.email === "admin@travel.et" && formData.password === "12345"){
                navigate('/')
                localStorage.setItem('logged', JSON.stringify("admin"))
                flag = true
            } else if (formData.email === user.email && formData.password === user.password){
                img = user.imgURL
                flag = true
                navigate('/', {
                    state: {
                        id : user.id,
                        img: img
                        }
                    })
                localStorage.setItem('logged', JSON.stringify("user"))
                localStorage.setItem('user', JSON.stringify(user.id))
            }
            
            localStorage.setItem('loggedIn', JSON.stringify(flag))
            localStorage.setItem('img', JSON.stringify(img))
        }
        if (flag === false){
            alert("Incorrect Login")
        }
    }

    function handleChange(event) {
        const {name, value} = event.target
        setFormData(prevFormData => ({
            ...prevFormData,
            [name]: value
        }))
    }
    return (
    <div className="form-outer">
    <div className="form-container">
    <form className="form" onSubmit={handleSubmit}>
        <img src="../../images/icon.png" alt="company logo" className='header--logo'/>
        <input 
            type="email" 
            placeholder="Email address"
            className="form--input"
            name="email"
            onChange={handleChange}
            value={formData.email}
        />
        <input 
            type="password" 
            placeholder="Password"
            className="form--input"
            name="password"
            onChange={handleChange}
            value={formData.password}
        />
        <button onClick={handleClick}>
            Log In
        </button>
        <div className="form--links">
            <NavLink to="/signup">Create new account</NavLink>
            <NavLink to="/">Home</NavLink>
        </div>
    </form>
    </div>
    </div>
)
}