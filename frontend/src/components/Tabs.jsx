import React from "react";

export default function Tabs({ active, onChange }) {
  return (
    <div className="tabs">
      <button
        className={`tab ${active === "invited" ? "active" : ""}`}
        onClick={() => onChange("invited")}
      >
        Invited
      </button>
      <button
        className={`tab ${active === "accepted" ? "active" : ""}`}
        onClick={() => onChange("accepted")}
      >
        Accepted
      </button>
    </div>
  );
}
