import React from "react";

import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import ArrowForwardIcon from "@mui/icons-material/ArrowForward";
import { Box, Typography } from "@mui/material";

import { saveOffsetLimit } from "../../../Integrations/LocalStorage";

const Pagination = ({ offset, limit, totalRecords, setOffset, tableName }) => {
  const nextPage = () => {
    if (offset + limit < totalRecords) {
      saveOffsetLimit(parseInt(offset) + parseInt(limit), limit, tableName);
      setOffset(offset + limit);
    }
  };
  const previousPage = () => {
    if (offset > 0) {
      saveOffsetLimit(parseInt(offset) - parseInt(limit), limit, tableName);
      setOffset(offset - limit);
    }
  };
  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "space-between",
        marginBottom: "10px",
      }}
    >
      <Typography>
        Showing {offset} to{" "}
        {parseInt(offset) + parseInt(limit) < totalRecords
          ? parseInt(offset) + parseInt(limit)
          : totalRecords}{" "}
        of {totalRecords}
      </Typography>{" "}
      <Box
        sx={{
          display: "flex",
          justifyContent: "flex-end",
          marginBottom: "10px",
        }}
      >
        <ArrowBackIcon
          style={{ marginRight: "15px", cursor: "pointer" }}
          fontSize={"large"}
          onClick={() => previousPage()}
        />
        <ArrowForwardIcon
          style={{ marginRight: "15px", cursor: "pointer" }}
          onClick={() => nextPage()}
          fontSize={"large"}
        />
      </Box>
    </Box>
  );
};
export default Pagination;
