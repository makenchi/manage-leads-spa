import { useEffect, useState } from "react";
import axios from "axios";

export const API_URL =
  "https://localhost:7002/Lead";

const TabType = {
  0: "INVITED",
  1: "ACCEPTED"
};

function groupByStatus(leads) {
  return leads
    .filter((it) => it.status !== 2)
    .reduce(
      (acc, it) => {
        acc[TabType[it.status]].push(it);
        return acc;
      },
      {
        INVITED: [],
        ACCEPTED: []
      }
    );
}

export function useLeads() {
  const [displayableLeads, setDisplayableLeads] = useState({
    leadType: 0,
    items: []
  });

  const [leads, setLeads] = useState({
    INVITED: null,
    ACCEPTED: null
  });

  const [request, setRequest] = useState({
    loading: true,
    error: null
  });

  async function loadData() {
    setRequest({ loading: true, error: null });

    try {
      const data = await axios
        .get(API_URL)
        .then(({ data }) => groupByStatus(data));
      setLeads(data);
      setDisplayableLeads({
        leadType: 0,
        items: data.INVITED
      });
      setRequest({ loading: false, error: null });
    } catch (err) {
      setRequest({ loading: false, error: err.message });
    }
  }

  useEffect(() => {
    loadData();
  }, []);

  function toggleStatus() {
    const leadType = displayableLeads.leadType === 0 ? 1 : 0;

    setDisplayableLeads({
      leadType,
      items: leads[TabType[leadType]]
    });
  }

  async function acceptLead(id) {
    setRequest({ loading: true, error: null });

    await axios.patch(
      "https://localhost:7002/Lead",
      {
        id,
        status : 1
      }
    );

    const data = await axios.get(API_URL).then(({ data }) => data);
    const allLeads = groupByStatus(
      data.map((it) => {
        if (it.id === id) return { ...it, status: 1 };
        return it;
      })
    );

    setDisplayableLeads({
      leadType: displayableLeads.leadType,
      items: allLeads[TabType[displayableLeads.leadType]]
    });

    setLeads(allLeads);
    setRequest({ loading: false, error: null });
  }

  async function declineLead(id) {
    setRequest({ loading: true, error: null });

    await axios.patch(
      "https://localhost:7002/Lead",
      {
        id,
        status : 2
      }
    );

    const data = await axios.get(API_URL).then(({ data }) => data);
    const allLeads = groupByStatus(
      data.map((it) => {
        if (it.id === id) return { ...it, status: 2 };
        return it;
      })
    );

    setDisplayableLeads({
      leadType: displayableLeads.leadType,
      items: allLeads[TabType[displayableLeads.leadType]]
    });

    setLeads(allLeads);
    setRequest({ loading: false, error: null });
  }

  return {
    leads: displayableLeads.items || [],
    toggleStatus,
    acceptLead,
    declineLead,
    leadType: displayableLeads.leadType || 0,
    error: request.error,
    loading: request.loading
  };
}
