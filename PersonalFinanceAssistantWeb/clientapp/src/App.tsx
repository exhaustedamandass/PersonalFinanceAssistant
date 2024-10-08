import React from 'react';
import logo from './logo.svg';
import './App.css';
import Accounts from './components/Accounts'

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>Account Manager</h1>
      </header>
      <Accounts />
    </div>
  );
}

export default App;
