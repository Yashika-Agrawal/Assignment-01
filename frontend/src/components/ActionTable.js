import React from "react";


const ActionTable = ({ actions }) => {
  return (
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
  );
};

export default ActionTable;
