import './App.css';
import React from 'react';
import {Home} from './components/Home';
import {Address} from './components/Address';
import {Match} from './components/Match';
import {Player} from './components/Player';
import {Training} from './components/Training';
import {Coach} from './components/Coach';
import {SportClub} from './components/SportClub';
import {User} from './components/User';
import {BrowserRouter, Route, Switch, NavLink} from 'react-router-dom';

function App() {
  return (
    <BrowserRouter>
      <div className="App container">
        <h3 className="d-flex justify-content-center m-3">
          React JS Frontend
        </h3>
        <nav className="navbar navbar-expand-sm bg-light navbar-dark">
          <ul className="navbar-nav">
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/">
                Home
              </NavLink>
            </li>
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/address">
                Address
              </NavLink>
            </li>
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/coach">
                Coach
              </NavLink>
            </li>
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/match">
                Match
              </NavLink>
            </li>
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/player">
                Player
              </NavLink>
            </li>
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/sportClub">
                Sport Club
              </NavLink>
            </li>
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/training">
                Training
              </NavLink>
            </li>
            <li className="nav-item- m-1">
              <NavLink className="btn btn-light btn-outline-primary" to="/user">
                User
              </NavLink>
            </li>
          </ul>
        </nav>

        <Switch>
          <Route path="/" component={Home}/>
          <Route path="/address" component={Address}/>
          <Route path="/coach" component={Coach}/>
          <Route path="/match" component={Match}/>
          <Route path="/training" component={Training}/>
          <Route path="/player" component={Player}/>
          <Route path="/sportClub" component={SportClub}/>
          <Route path="/user" component={User}/>
        </Switch>
      </div>
    </BrowserRouter>
  );
}

export default App;