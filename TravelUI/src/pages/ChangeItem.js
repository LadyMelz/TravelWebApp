import React, {useState, useEffect} from 'react'
import { useNavigate, useLocation } from 'react-router-dom';
export default function AddItem(){
  const location = useLocation()
  const navigate = useNavigate()
  const [attraction, setAttraction] = useState({
    title: "",
    short_Description: "",
    long_Description: "",
    link: "",
    location: "",
    imgURL: ""
  })

  const [event, setEvent] = useState({
    title: "",
    short_Description: "",
    long_Description: "",
    link: "",
    location: "",
    date: "",
    imgURL: ""
  })

  useEffect(() => {
    const fetchCard = async () => {
    const res = await fetch(`https://localhost:7046/api/${location.state.buttonPressed}/${location.state.id}`)
    const data = await res.json()
    console.log(location.state.buttonPressed)
    console.log(location.state.id)
    
    location.state.buttonPressed === "attraction" ? setAttraction(data) : setEvent(data)
    
    }
    fetchCard().catch((error) => console.error(error));
  }, []);

  async function editAttraction(){
    try {
      const response = await fetch(`https://localhost:7046/api/Attraction/${location.state.id}`, {
      method: 'PUT',
      headers: {
          'Content-Type': 'application/json',
      },
      body: JSON.stringify(attraction),
      });

      if (response.ok) {
      console.log('Form data submitted successfully');
      navigate('/admin')
      // You might want to handle success here, like showing a success message
      } else {
      console.error('Error submitting form data');
      // Handle the error scenario here, like showing an error message
      }
  } catch (error) {
    console.error('An error occurred', error);
  }
  }
  async function editEvent(){
    try {
      const response = await fetch(`https://localhost:7046/api/Event/${location.state.id}`, {
      method: 'PUT',
      headers: {
          'Content-Type': 'application/json',
      },
      body: JSON.stringify(event),
      });

      if (response.ok) {
      console.log('Form data submitted successfully');
      navigate('/admin')
      // You might want to handle success here, like showing a success message
      } else {
      console.error('Error submitting form data');
      // Handle the error scenario here, like showing an error message
      }
  } catch (error) {
    console.error('An error occurred', error);
  }
  }

  function handleAttractionChange(event){
    const {name, value,} = event.target
      setAttraction(prevFormData => ({
            ...prevFormData,
            [name]: value
        }))
  }

  function handleEventChange(event){
    const {name, value,} = event.target
      setEvent(prevFormData => ({
            ...prevFormData,
            [name]: value
        }))
  }
    function handleSubmit(event){
      event.preventDefault()
    }
  if(location.state.buttonPressed === "attraction"){
      return(
        <div className="form-outer">
        <div className="form-container">
        <form className="form" onSubmit={handleSubmit}>
          <h2>Edit</h2>
            <input 
              placeholder="Title" 
              name="title" 
              className='form--input'
              onChange={handleAttractionChange} 
              value={attraction.title}
            />
            <input 
              placeholder="Short Description" 
              name="short_Description"
              className='form--input'
              onChange={handleAttractionChange} 
              value={attraction.short_Description}
            />
            <input 
              placeholder="Long Description" 
              name="long_Description"
              className='form--input'
              onChange={handleAttractionChange} 
              value={attraction.long_Description}
            />
            <input 
              placeholder="Link" 
              name="link"
              className='form--input'
              onChange={handleAttractionChange} 
              value={attraction.link}
            />
            <input 
              placeholder="Location" 
              name="location" 
              className='form--input'
              onChange={handleAttractionChange} 
              value={attraction.location}
            />
            <input 
              placeholder="Img URL" 
              name="imgURL" 
              className='form--input'
              onChange={handleAttractionChange} 
              value={attraction.imgURL}
            />
          <div className='form--links'>
            <span className='form-link' onClick={editAttraction}>Done</span>
            <span className='form-link' onClick={()=> navigate(-1)}>Cancel</span>
          </div>
        </form>
        </div>
        </div>
      )
    
  } else if(location.state.buttonPressed === "event"){
    return(
      <div className="form-outer">
      <div className="form-container">
      <form className="form" onSubmit={handleSubmit}>
        <h2>Edit</h2>
          <input 
            placeholder="Title" 
            name="title" 
            className='form--input'
            onChange={handleEventChange} 
            value={event.title}
          />
          <input 
            placeholder="Short Description" 
            name="short_Description" 
            className='form--input'
            onChange={handleEventChange} 
            value={event.short_Description}
          />
          <input 
            placeholder="Long Description" 
            name="long_Description"
            className='form--input' 
            onChange={handleEventChange} 
            value={event.long_Description}
          />
          <input 
            placeholder="Link" 
            name="link" 
            className='form--input'
            onChange={handleEventChange} 
            value={event.link}
          />
          <input 
            placeholder="Location" 
            name="location" 
            className='form--input'
            onChange={handleEventChange} 
            value={event.location}
          />
          <input
            type='date'
            placeholder="Date" 
            name="date" 
            className='form--input'
            onChange={handleEventChange} 
            value={event.date}
          />
          <input 
            placeholder="Img URL" 
            name="imgURL" 
            className='form--input'
            onChange={handleEventChange} 
            value={event.imgURL}
          />
          <div className='form--links'>
            <span className='form-link' onClick={editEvent}>Done</span>
            <span className='form-link' onClick={()=> navigate(-1)}>Cancel</span>
          </div>
      </form>
      </div>
      </div>
    )
  }
}