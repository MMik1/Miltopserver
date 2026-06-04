export default async function handler(req, res) {
  try {
    const { start_date, end_date } = req.query;

    const url =
      `https://tbundertje.gwmn.nl/api/v2/measurements/gws/` +
      `?start_date=${start_date}` +
      `&end_date=${end_date}`;

    const response = await fetch(url);
    const data = await response.json();

    res.status(200).json(data);
  } catch (err) {
    res.status(500).json({
      error: "Kon grondwater niet ophalen",
      message: err.message,
    });
  }
}