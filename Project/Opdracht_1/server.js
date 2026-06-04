import express from "express";
import cors from "cors";

const app = express();

app.use(cors());

app.get("/api/grondwater", async (req, res) => {
  try {
    const { start_date, end_date } = req.query;

    const url =
      `https://tbundertje.gwmn.nl/api/v2/measurements/gws/` +
      `?start_date=${start_date}` +
      `&end_date=${end_date}`;

    console.log("Naar Bundertje:", url);

    const response = await fetch(url);
    const text = await response.text();

    console.log("Status:", response.status);
    console.log("Antwoord:", text);

    res.status(response.status).send(text);
  } catch (err) {
    console.error("SERVER ERROR:", err);
    res.status(500).json({ error: err.message });
  }
});

app.listen(3000, () => {
  console.log("Server draait op http://localhost:3000");
});