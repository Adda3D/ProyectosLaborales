import { NotificationManager } from "react-notifications";

export const errorHandle = (e, genericName) => {
  let errorMessage = null;
  if (e?.response?.data?.message) {
    errorMessage = e.response.data.message;
  }
  if (!errorMessage) {
    errorMessage = e.message;
  }
  if (!errorMessage) {
    errorMessage = `Error In ${genericName}: ${JSON.stringify(e)}`;
  }
  NotificationManager.error(errorMessage);
};
