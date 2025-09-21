import React, { useState } from "react";
import InvitedPage from "./pages/InvitedPage";
import AcceptedPage from "./pages/AcceptedPage";
import Tabs from "./components/Tabs";

export default function App() {
  const [tab, setTab] = useState("invited");

  return (
    <div className="app-container">
      <h1 className="app-title">Lead Manager</h1>
      <Tabs active={tab} onChange={setTab} />
      <div className="content">
        {tab === "invited" ? <InvitedPage /> : <AcceptedPage />}
      </div>
    </div>
  );
}
