import React, { useEffect, useState } from "react";
import { getAcceptedLeads } from "../api/leadsApi";
import LeadCard from "../components/LeadCard";
import Loader from "../components/Loader";

export default function AcceptedPage() {
  const [leads, setLeads] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  async function load() {
    setLoading(true);
    try {
      const data = await getAcceptedLeads();
      setLeads(Array.isArray(data) ? data : []); 
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

  if (loading) return <Loader />;
  if (error) return <div>Ocorreu um erro: {error.message}</div>;

  return (
    <div className="list">
      {leads.length === 0 && (
        <div className="empty">Nenhum lead aceito</div>
      )}
      {leads.map((lead) => (
        <LeadCard key={lead.id} lead={lead} mode="accepted" />
      ))}
    </div>
  );
}
