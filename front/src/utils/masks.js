// src/utils/masks.js
import { format } from 'date-fns';
import { ptBR } from 'date-fns/locale';

export const maskDate = (date) => {
  if (!date) return '';
  try {
    const parsedDate = new Date(date);
    return format(parsedDate, 'dd/MM/yyyy', { locale: ptBR });
  } catch (error) {
    console.error("Error parsing date:", error);
    return date;
  }
};
