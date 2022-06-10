import styled from "@emotion/styled";
import { useState } from "react";
import { useMutation, useQuery, useQueryClient } from "react-query";
import { LeadCard } from "../../components/cards/lead-card";
import { LeadCardAccepted } from "../../components/cards/lead-card-accepted";
import Tabs from "../../components/tabs/tabs";
import { CardLoading } from "./components/leads.loading";
import {
  getAcceptedLeads,
  getAvailableLeads,
  getLeadByStatus,
  useLeads
} from "./leads.services";

const Main = styled.main`
  max-width: 100%;
  width: 600px;
  min-height: 300px;
  padding: 8px;
  background-color: #ededed;
`;

const items = [
  {
    label: "Invited",
    data: [
      {
        customer: "ABC"
      }
    ]
  },
  {
    label: "Accepted",
    data: [
      {
        customer: "DEF"
      }
    ]
  }
];

export const LeadsScreen = () => {
  const {
    loading,
    leads: data,
    toggleStatus,
    acceptLead,
    declineLead,
    leadType
  } = useLeads();

  function handleTabChange(i) {
    toggleStatus();
  }

  function handleBtnClick(leadId) {
    acceptLead(leadId);
  }

  function handleBtnClickDcln(leadId) {
    declineLead(leadId);
  }  

  const Card = leadType === 0 ? LeadCard : LeadCardAccepted;

  return (
    <Main>
      <Tabs items={items} onChange={handleTabChange} index={leadType} />
      {loading && <CardLoading />}
      {!loading &&
        data.map((it) => (
          <>
            <Card {...it} onAccept={handleBtnClick} onDecline={handleBtnClickDcln} />
          </>
        ))}
    </Main>
  );
};
