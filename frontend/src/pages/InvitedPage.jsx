import React, { useEffect, useState } from "react";
import { getInvitedLeads, acceptLead, declineLead } from "../api/leadsApi";
import LeadCard from "../components/LeadCard";
import Loader from "../components/Loader";

export default function InvitedPage() {
  const [leads, setLeads] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  async function load() {
    setLoading(true);
    setError(null);
    try {
      const data = await getInvitedLeads();

      if (Array.isArray(data)) {
        setLeads(data);
      } else if (data && Array.isArray(data.leads)) {
        setLeads(data.leads);
      } else {
        setLeads([]);
      }
    } catch (err) {
      setError(err);
      setLeads([]);
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    load();
  }, []);

  async function handleAccept(id) {
    try {
      await acceptLead(id);
      setLeads((prev) => prev.filter((l) => l.id !== id));
     
      window.dispatchEvent(new Event("leadAccepted"));
    } catch (err) {
      console.error(err);
      alert("Erro ao aceitar lead");
    }
  }

  async function handleDecline(id) {
    try {
      await declineLead(id);
      setLeads((prev) => prev.filter((l) => l.id !== id));
    } catch (err) {
      console.error(err);
      alert("Erro ao recusar lead");
    }
  }

  if (loading) return <Loader />;
  if (error) return <div>Ocorreu um erro: {error.message}</div>;

  return (
    <div className="list">
      {(!Array.isArray(leads) || leads.length === 0) && !loading && (
        <div className="empty">Nenhum lead convidado</div>
      )}

      {Array.isArray(leads) &&
        leads.map((lead) => (
          <LeadCard
            key={lead.id}
            lead={lead}
            mode="invited"
            onAccept={handleAccept}
            onDecline={handleDecline}
          />
        ))}
    </div>
  );
}
