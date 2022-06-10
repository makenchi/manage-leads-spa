import { Avatar, Card, CardHeader, Divider, Grid, Stack } from "@mui/material";

export const LeadCardAccepted = ({ name, onAccept }) => (
  <Grid margin={1}>
    <Card>
      <CardHeader
        avatar={
          <Avatar sx={{ bgcolor: "#fe7d2b" }} aria-label="recipe">
            {name.substring(0, 1)}
          </Avatar>
        }
        title={name}
        subheader="September 14, 2016"
      />
      <Divider />
      <Stack spacing={2} padding={1} direction="row" alignItems="center">
        <span>Yandere 2574</span>
        <span>Painters</span>
        <span>Job Id: 557777</span>
        <span>
          <b>$ 49,00</b> Lead Invitation
        </span>
      </Stack>

      <Divider />
      <Grid padding={1}>
        <Stack spacing={2} direction="row" alignItems="center">
          <span>Yandere 2574</span>
          <span>Painters</span>
        </Stack>
        <p>ABC</p>
      </Grid>
    </Card>
  </Grid>
);
