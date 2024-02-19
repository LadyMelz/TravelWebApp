import React, { useState, useEffect } from "react";
import {useNavigate} from "react-router-dom"
import Nav from '../components/Nav';
import Header from '../components/Header';


export default function Admin(){
    const navigate = useNavigate()
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
            <td><img src="../../images/delete.png" className="icon" /></td>
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
            <td><img src="../../images/delete.png" className="icon"/></td>
        </tr>
        );
      });

    return(
        <>
            <Header/>
            <div className='container'>
                <Nav 
                  imgSrc="default-profile.png" 
                  status="admin" 
                  name="Log Out"
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