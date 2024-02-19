import { NavLink } from 'react-router-dom';
 
const NavBar = () => {
   return (
   <div className='navbar'>
         <ul>
            <li>
               <NavLink to="/">Home</NavLink>
            </li>
            <li>
               <NavLink to="/attractions">Attractions</NavLink>
            </li>
            <li>
               <NavLink to="/events">Events</NavLink>
            </li>
         </ul>
   </div>
   );
};
 
export default NavBar;