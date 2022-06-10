import axios from "axios";
export const fetcher = (url) =>
  axios
    .get(url)
    .then((res) => res.data)
    .then(async (data) => {
      const delay = (ms) => new Promise((resolve) => setTimeout(resolve, ms));

      await delay(3000);
      return data;
    });
