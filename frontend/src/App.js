import React, { useState } from "react";
import axios from "axios";
import "./App.css"; // Import the CSS file

const App = () => {
  const [actions, setActions] = useState([]);
  const [username] = useState("user1");
  const [actionName] = useState("button-clicked");

  const handleClick = async () => {
    try {
      const res = await axios.post("http://localhost:5280/api/ClickAction", {
        username: username,
        id: Math.floor(Math.random() * 1000).toString(), // Convert id to string
        actionName: actionName,
      });
      console.log("response", res);
      alert("Action stored successfully!");
    } catch (error) {
      console.error(error);
      alert("Failed to store action");
    }
  };

  const handleGetActions = async () => {
    try {
      const response = await axios.get("http://localhost:5280/api/ClickAction");
      setActions(response.data);
    } catch (error) {
      console.error(error);
      alert("Failed to fetch actions");
    }
  };

  return (
    <div className="container">
      <div className="box">
        <button className="button" onClick={handleClick}>
          Click Me!
        </button>
      </div>
      <div className="box">
        <button className="button" onClick={handleGetActions}>
          Get Me!
        </button>
        {actions.length > 0 && (
          <table className="actions-table">
            <thead>
              <tr>
                <th>UTC DateTime</th>
                <th>Username</th>
                <th>Action Name</th>
              </tr>
            </thead>
            <tbody>
              {actions.map((action) => (
                <tr key={action.id}>
                  <td>{new Date(action.utcDateTime).toLocaleString()}</td>
                  <td>{action.username}</td>
                  <td>{action.actionName}</td>
                </tr>
              ))}
            </tbody>
          </table>
        )}
      </div>
    </div>
  );
};

export default App;
