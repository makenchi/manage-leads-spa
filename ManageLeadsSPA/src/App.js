import { LeadsScreen } from "./features/leads/leads.screen";
import "./styles.css";
import { QueryClient, QueryClientProvider } from "react-query";
const queryClient = new QueryClient();

export default function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <LeadsScreen />
    </QueryClientProvider>
  );
}
