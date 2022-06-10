import {
  Avatar,
  Button,
  Card,
  CardHeader,
  Divider,
  Grid,
  Stack
} from "@mui/material";

export const LeadCard = ({ firstName, id, dateCreated, suburb, category, description, price, onAccept, onDecline }) => (
  <Grid margin={1}>
    <Card>
      <CardHeader
        avatar={
          <Avatar sx={{ bgcolor: "#fe7d2b" }} aria-label="recipe">
            {firstName.substring(0, 1)}
          </Avatar>
        }
        title={firstName}
        subheader={dateCreated}
      />
      <Divider />
      <Stack spacing={2} padding={1} direction="row" alignItems="center">
        <span>{suburb}</span>
        <span>{category}</span>
        <span>Job Id: {id}</span>
      </Stack>

      <Divider />
      <Grid padding={1}>
        <p>{description}</p>
      </Grid>
      <Divider />
      <Stack spacing={2} padding={1} direction="row" alignItems="center">
        <Button variant="contained" onClick={() => onAccept(id)}>
          Accept
        </Button>
        <Button variant="outlined" onClick={() => onDecline(id)}>Decline</Button>
        <span>
          <b>$ {price}</b> Lead Invitation
        </span>
      </Stack>
    </Card>
  </Grid>
);
