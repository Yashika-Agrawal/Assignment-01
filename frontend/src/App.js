import React, { useState } from "react";
import axios from "axios";
import ActionTable from "./components/ActionTable";
import Button from "./components/Button";
import "./App.css";

const App = () => {
  const [actions, setActions] = useState([]);
  const [username] = useState("user1");
  const [actionName] = useState("button-clicked");

  const handleClick = async () => {
    try {
      const res = await axios.post("http://localhost:5280/api/ClickAction", {
        username: username,
        id: Math.floor(Math.random() * 1000).toString(), 
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
        <Button onClick={handleClick} text="Click Me!" />
      </div>
      <div className="box">
        <Button onClick={handleGetActions} text="Get Me!" />
        {actions.length > 0 && <ActionTable actions={actions} />}
      </div>
    </div>
  );
};

export default App;
