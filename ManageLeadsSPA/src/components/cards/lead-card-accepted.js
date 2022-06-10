import { Avatar, Card, CardHeader, Divider, Grid, Stack } from "@mui/material";

export const LeadCardAccepted = ({ firstName, lastName, id, dateCreated, suburb, category, description, price, email, phone, onAccept }) => (
  <Grid margin={1}>
    <Card>
      <CardHeader
        avatar={
          <Avatar sx={{ bgcolor: "#fe7d2b" }} aria-label="recipe">
            {firstName.substring(0, 1)}
          </Avatar>
        }
        title={firstName + " " + lastName}
        subheader={dateCreated}
      />
      <Divider />
      <Stack spacing={2} padding={1} direction="row" alignItems="center">
        <span>{suburb}</span>
        <span>{category}</span>
        <span>Job Id: {id}</span>
        <span>
          <b>$ {price}</b> Lead Invitation
        </span>
      </Stack>

      <Divider />
      <Grid padding={1}>
        <Stack spacing={2} direction="row" alignItems="center">
          <span>{phone}</span>
          <span>{email}</span>
        </Stack>
        <p>{description}</p>
      </Grid>
    </Card>
  </Grid>
);
