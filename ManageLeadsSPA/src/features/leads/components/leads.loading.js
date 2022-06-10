import { Skeleton } from "@mui/material";
import React from "react";

export const CardLoading = () => (
  <>
    <Skeleton
      variant="rect"
      width="100%"
      height={200}
      style={{ marginTop: 10 }}
    />
    <Skeleton
      variant="rect"
      width="100%"
      height={200}
      style={{ marginTop: 10 }}
    />
  </>
);
