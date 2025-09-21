import React from "react";

export default function LeadCard({
  lead,
  mode = "invited",
  onAccept,
  onDecline,
}) {
  const date = new Date(
    lead.createdAt || lead.CreatedAt || lead.CreatedAtUtc || lead.CreatedAtDate
  );
  const formattedDate = date.toLocaleString();

  return (
    <div className="lead-card">
      <div className="lead-header">
        <div className="avatar">
          {lead.contactFirstName?.[0] || lead.contactFullName?.[0] || "U"}
        </div>
        <div>
          <div className="lead-name">
            {mode === "invited" ? lead.contactFirstName : lead.contactFullName}
          </div>
          <div className="lead-date">{formattedDate}</div>
        </div>
      </div>

      <div className="lead-meta">
        <span className="meta-item">📍 {lead.suburb}</span>
        <span className="meta-item">💼 {lead.category}</span>
        <span className="meta-item">Job ID: {lead.id}</span>
      </div>

      <div className="lead-desc">{lead.description}</div>

      <div className="lead-footer">
        <div className="price">${lead.price?.toFixed(2)}</div>
        {mode === "invited" ? (
          <div className="actions">
            <button className="btn accept" onClick={() => onAccept(lead.id)}>
              Accept
            </button>
            <button className="btn decline" onClick={() => onDecline(lead.id)}>
              Decline
            </button>
          </div>
        ) : (
          <div className="contact">
            <div>📞 {lead.contactPhone}</div>
            <div>✉️ {lead.contactEmail}</div>
          </div>
        )}
      </div>
    </div>
  );
}
