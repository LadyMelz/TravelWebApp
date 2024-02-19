import React, { useState, useEffect } from "react";
import ICard from "./ICard";
//import AData from "../attractionData";
import { useNavigate } from "react-router-dom";
//import EData from "../eventData";

export default function Card(props) {
  const [card, setCard] = useState([]);

  if (props.title === "Attractions"){
    var path = 'attraction'
  } else if(props.title === "Events"){
    var path = 'event'
  }else var path = 'itinerary'
 
  useEffect(() => {
    const fetchCard = async () => {
    const res = await fetch(`https://localhost:7046/api/${path}`)
    const data = await res.json()
      setCard(data) 
      
    }
    fetchCard().catch((error) => console.error(error));
  }, []);

  console.log(card)

    const iCard = card.map((item) => {
    return <ICard key={item.id} img={item.imgURL} {...item} />;
  });
  const navigate = useNavigate();
  return (
    <div className="card-box">
      <h2
        className="card-title"
        onClick={() =>
          props.title === "Attractions"
            ? navigate("attractions")
            : navigate("events")
        }
      >
        {props.title}
      </h2>
      <section className="card-list">{iCard}</section>
    </div>
  );
}
