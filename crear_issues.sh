#!/bin/bash

# Array con los 30 requerimientos
issues=(
  "RF01: Identificación y acceso del usuario"
  "RF02: Perfil del atleta"
  "RF03: Creación de plantillas de rutinas"
  "RF04: Registro de series, peso y repeticiones"
  "RF05: Registro de esfuerzo percibido (RPE)"
  "RF06: Cálculo de 1RM estimado"
  "RF07: Visualizador de carga de barra IPF"
  "RF08: Series de aproximación e intensidades"
  "RF09: Gestión de intentos en competencia"
  "RF10: Cálculo de puntuación oficial DOTS"
  "RF11: Calculadora de aproximación"
  "RF12: Temporizador por ejercicio"
  "RF13: Notas visuales y multimedia"
  "RF14: Sugerencia de progresión semanal"
  "RF15: Comparador de sesiones históricas"
  "RF16: Entrenamiento rápido (Sesión libre)"
  "RF17: Edición de sesiones registradas"
  "RF18: Dashboard inicial"
  "RF19: Buscador y filtros en catálogo de ejercicios"
  "RF20: Creación de ejercicios personalizados"
  "RF21: Buscador global de rutinas"
  "RF22: Duplicación de plantillas de rutina"
  "RF23: Reordenamiento drag-and-drop de ejercicios"
  "RF24: Reemplazo de ejercicio en vivo"
  "RF25: Indicador visual de Récord Personal (PR)"
  "RF26: Configuración de peso de barra base"
  "RF27: Toggle de cálculo de seguros/collars"
  "RF28: Desglose de tonelaje e intensidad de la sesión"
  "RF29: Historial detallado por ejercicio específico"
  "RF30: Exportación de entrenamientos (CSV / PDF)"
)

# Bucle que crea cada issue
for title in "${issues[@]}"; do
  echo "Creando issue: $title..."
  gh issue create --title "$title" --body "Requerimiento funcional correspondiente al desarrollo del sistema LifterLab."
done

echo "¡Listo! Los 30 issues han sido creados correctamente."
