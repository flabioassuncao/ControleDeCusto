import { Funcionario } from './funcionario';

export class Movimentacao {
    id: string;
    descricao: string;
    valor: number;
    funcionarioId: string;
    funcionario: Funcionario;
}
