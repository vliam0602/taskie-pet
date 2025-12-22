import type { DailyTask } from "../api/models";

export interface User {
  email: string;
  passwordHash: string;
  dailyTasks: DailyTask[];
}
