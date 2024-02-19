import React, { useState, useEffect } from "react";
import Popup from 'reactjs-popup';
import Header from '../components/Header'
import Hero from '../components/Hero'
import Footer from '../components/Footer'
import Cards from '../components/Cards'
import Nav from '../components/Nav'
import {useNavigate, useLocation} from "react-router-dom"
import Itinerary from '../components/Itinerary'


function Home() {
  const location = useLocation()
  const navigate = useNavigate()
  const flag = JSON.parse(localStorage.getItem('loggedIn'))
  const logged = JSON.parse(localStorage.getItem('logged'))
  const img = JSON.parse(localStorage.getItem('img'))
  const id = JSON.parse(localStorage.getItem('user'))
  const [attraction, setAttraction] = useState([]);
  const [event, setEvent] = useState([]);
      useEffect(() => {
        const fetchCard = async () => {
        const res = await fetch(`https://localhost:7046/api/attraction`)
        const data = await res.json()
          setAttraction(data)
        }
        fetchCard().catch((error) => console.error(error));
      }, []);

      useEffect(() => {
        const fetchCard = async () => {
        const res = await fetch(`https://localhost:7046/api/event`)
        const data = await res.json()
          setEvent(data)
        }
        fetchCard().catch((error) => console.error(error));
      }, []);

      function confirmDeleteAttraction(id){
        try {
            fetch(`https://localhost:7046/api/Attraction/${id}`, {
            method: 'delete',
            header: {
                'Content-Type': 'application/problem+json; charset=utf-8'
            }
             })
            navigate('/')
             
        } catch (error) {
            console.error('An error occurred', error);
        }
        console.log("deleting...")
      }

      const eventRow = event.map((item) => {
        return (
            <tr>
            <td>{item.id}</td>
            <td>{item.title}</td>
            <td> <div className="autoHide">{item.short_Description}</div></td>
            <td> <div className="autoHide">{item.long_Description}</div></td>
            <td>{item.link}</td>
            <td>{item.location}</td>
            <td>{item.date}</td>
            <td>{item.imgURL}</td>
            <td><img src="../../images/edit.png" className="icon" onClick={()=>{
                      navigate('changeItem', {
                      state: {
                          buttonPressed: "event",
                          id: item.id
                          }})}}/></td>
            <td><img src="../../images/delete.png" className="icon" onClick={()=>{
                      navigate('deleteItem', {
                      state: {
                          buttonPressed: "event",
                          id: item.id,
                          flag: true
                          }})}}/></td>
            </tr>
            );
        
      });
      const attractionRow = attraction.map((item) => {
        return (
        <tr>
            <td>{item.id}</td>
            <td>{item.title}</td>
            <td><div className="autoHide">{item.short_Description}</div></td>
            <td><div className="autoHide">{item.long_Description}</div></td>
            <td>{item.link}</td>
            <td>{item.location}</td>
            <td>{item.imgURL}</td>
            <td><img src="../../images/edit.png" className="icon" onClick={()=>{
                      navigate('changeItem', {
                      state: {
                          buttonPressed: "attraction",
                          id: item.id
                          }})}}/></td>
            <td><Popup trigger={<img src="../../images/delete.png" className="icon" />} position="top right">
              <div>
                  <p>Are you sure you want to delete this attraction?</p>
                  <span className="form-link" id={item.id} onClick={confirmDeleteAttraction}>Yes</span>
                  <span className="form-link" >No</span>
              </div>
            </Popup>
            </td>
        </tr>
        );
      });


  function create(){
    navigate('/create', {
      state: {
        id : id
      }
    })
  }
  function view(){
    navigate('/view', {
      state: {
        id : id
      }
    })
  }
  function setting(){
    navigate('/settings', {
      state: {
        id : id
      }
    })
  }
  if(logged === 'admin' && flag)
  {
    return(
      <>
            <Header/>
            <div className='container'>
                <Nav 
                  imgSrc="default-profile.png" 
                  status="admin" 
                  name="Log Out"
                  create={create}
                  view={()=>{
                    navigate('/view', {
                    state: {
                        id : 2
                        }
                    })}}/>
                <div className='container--main'>
                    <h2>Attractions</h2>
                    <table>
                        <thead>
                            <td>Id</td>
                            <td>Title</td>
                            <td>Short Description</td>
                            <td>Long Description</td>
                            <td>Link</td>
                            <td>Location</td>
                            <td>Image Url</td>
                        </thead>
                        {attractionRow}
                    </table>
                    <button onClick={()=>{
                      navigate('addItem', {
                      state: {
                          buttonPressed: "attraction"
                          }
                      })}}>Add Item</button>
                    <br/>
                    <h2>Events</h2>
                    <table>
                        <thead>
                            <td>Id</td>
                            <td>Title</td>
                            <td>Short Description</td>
                            <td>Long Description</td>
                            <td>Link</td>
                            <td>Location</td>
                            <td>Date</td>
                            <td>Image Url</td>
                        </thead>
                        {eventRow}
                    </table>
                    <button onClick={()=>{
                      navigate('addItem', {
                      state: {
                          buttonPressed: "event"
                          }
                      })}}>Add Item</button>
                </div>
            </div>
        </>
    )
  }
  else{
  return (
    <>
    <Header/>
      <div className='container'>
        <div>
          {flag ? <Nav 
            imgSrc={img} 
            status="online" 
            name="Log Out" 
            create={create}
            view={view}
            setting={setting}/> : <Nav imgSrc="default-profile.png" status="--..--" name="Log In" />}
        </div>
        <div className='container--main'>
          {flag ? <Itinerary/> : <Hero />}
            <Cards title="Attractions"/>
            <Cards title="Events"/>
          </div>
      </div>
      <Footer />
    </>

    
  );
}
}

export default Home;
