import type { DailyTask as DailyTaskSingle } from "./generated";
import type { DailyTask2 as DailyTaskFromList } from "./generated";

export type DailyTask = DailyTaskSingle & DailyTaskFromList;
