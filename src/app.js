import express from "express";
import cors from "cors";
import morgan from "morgan";
import helmet from "helmet";

import "dotenv/config";

import { errorHandler, notFound } from "./middlewares";

import api from "./api";

const app = express();

app.use(morgan("dev"));
app.use(helmet());
app.use(cors());
app.use(express.json());

app.get("/", (req, res) => {
  res.json({
    message: "hello World",
  });
});

app.use("/api/v1", api);

app.use(notFound);
app.use(errorHandler);

export default app;
