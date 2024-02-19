import React from 'react'
import { Routes, Route} from 'react-router-dom';
import Home from './pages/Home'
import LogIn from './pages/LogIn'
import Events from './pages/Events'
import Attractions from './pages/Attractions'
import SignUp from './pages/SignUp'
import './index.css'
import Admin from './pages/Admin';
import ViewPage from './pages/ViewPage';
import Profile from './pages/Profile'
import Settings from './pages/Settings';
import AddItem from './pages/AddItem';
import ChangeItem from './pages/ChangeItem';
import DeleteItem from './pages/DeleteItem';
import ViewItinerary from './pages/ViewItinerary';
import CreateItinerary from './pages/CreateItinerary';

function App() {
  return (
    <>
         <Routes>
            <Route path="/" element={<Home/>} />
            <Route path="/login" element={<LogIn />} />
            <Route path="/signup" element={<SignUp />} />
            <Route path="/events" element={<Events />} />
            <Route path="/attractions" element={<Attractions />} />
            <Route path="/admin" element={<Admin />} />
            <Route path="/viewpage" element={<ViewPage />}/>
            <Route path ="/profile" element={<Profile/>}/>
            <Route path ="/settings" element={<Settings/>}/>
            <Route path ="/view" element={<ViewItinerary/>}/>
            <Route path ="/create" element={<CreateItinerary/>}/>
            <Route path ="/addItem" element={<AddItem/>}/>
            <Route path ="/changeItem" element={<ChangeItem/>}/>
            <Route path ="/deleteItem" element={<DeleteItem/>}/>
        
         </Routes>
    </>

    
  );
}

export default App;
