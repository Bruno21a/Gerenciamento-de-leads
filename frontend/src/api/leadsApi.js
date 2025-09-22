import axios from "axios";

const BASE = import.meta.env.VITE_API_BASE_URL || "http://localhost:3000/api";
const client = axios.create({
  baseURL: BASE,
  headers: { "Content-Type": "application/json" },
});



export async function getInvitedLeads() {
  const res = await fetch("https://localhost:7167/api/Leads/invited");
  if (!res.ok) throw new Error("Erro ao buscar leads convidados");
  return await res.json(); // já vem como array []
}

export async function getAcceptedLeads() {
  const res = await fetch("https://localhost:7167/api/Leads/accepted");
  if (!res.ok) throw new Error("Erro ao buscar leads aceitos");
  return await res.json();
}

export async function acceptLead(id) {
  const res = await fetch(`https://localhost:7167/api/Leads/${id}/accept`, {
    method: "POST"
  });
  if (!res.ok) throw new Error("Erro ao aceitar lead");
  return await res.json();
}

export async function declineLead(id) {
  const res = await fetch(`https://localhost:7167/api/Leads/${id}/decline`, {
    method: "POST"
  });
  if (!res.ok) throw new Error("Erro ao recusar lead");
  return await res.json();
}
